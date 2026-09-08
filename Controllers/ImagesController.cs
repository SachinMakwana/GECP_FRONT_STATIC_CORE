using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GECP_Front_End_Static.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public ImagesController(IWebHostEnvironment env) => _env = env;

        // Example: /images/resize?path=/DataFiles/Images/pic.jpg&w=800&q=75
        [HttpGet("/images/resize")]
        public IActionResult Resize(string path, int w = 0, int h = 0, int q = 75)
        {
            if (string.IsNullOrWhiteSpace(path)) return BadRequest();
            if (path.Contains("..")) return BadRequest();

            var rel = path.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var src = Path.Combine(_env.WebRootPath, rel);
            if (!System.IO.File.Exists(src)) return NotFound();

            // Generate cache key
            var key = $"{rel}|w={w}|h={h}|q={q}";
            using var sha = SHA1.Create();
            var cacheName = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(key))).Replace("-", "").ToLower();
            // Decide output format based on Accept header (prefer WebP when supported)
            var accept = Request.Headers["Accept"].ToString();
            var wantWebP = !string.IsNullOrEmpty(accept) && accept.IndexOf("image/webp", StringComparison.OrdinalIgnoreCase) >= 0;
            var ext = wantWebP ? "webp" : "jpg";
            var cacheDir = Path.Combine(_env.WebRootPath, "cache");
            Directory.CreateDirectory(cacheDir);
            var cachePath = Path.Combine(cacheDir, cacheName + "." + ext);

            if (System.IO.File.Exists(cachePath))
            {
                Response.Headers["Cache-Control"] = "public, max-age=31536000";
                var contentType = wantWebP ? "image/webp" : "image/jpeg";
                return PhysicalFile(cachePath, contentType);
            }

            using (var image = Image.Load(src))
            {
                if (w > 0 || h > 0)
                {
                    var size = new SixLabors.ImageSharp.Size(w > 0 ? w : 0, h > 0 ? h : 0);
                    var opts = new ResizeOptions { Mode = ResizeMode.Max, Size = size };
                    image.Mutate(x => x.Resize(opts));
                }

                using var ms = new MemoryStream();
                if (wantWebP)
                {
                    var webp = new WebpEncoder { Quality = Math.Clamp(q, 20, 95) };
                    image.Save(ms, webp);
                }
                else
                {
                    var encoder = new JpegEncoder { Quality = Math.Clamp(q, 20, 95) };
                    image.Save(ms, encoder);
                }
                ms.Position = 0;
                // persist cache
                using (var fs = System.IO.File.Create(cachePath)) ms.CopyTo(fs);
                Response.Headers["Cache-Control"] = "public, max-age=31536000";
                var finalContentType = wantWebP ? "image/webp" : "image/jpeg";
                return File(ms.ToArray(), finalContentType);
            }
        }
    }
}
