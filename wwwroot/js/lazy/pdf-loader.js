// Lightweight PDF loader: loads PDFObject on demand and embeds PDFs
(function (window, document) {
    function loadScriptOnce(src, cb, err) {
        if (document.querySelector('script[src="' + src + '"]')) {
            cb && cb();
            return;
        }
        var s = document.createElement('script');
        s.src = src;
        s.onload = function () { cb && cb(); };
        s.onerror = function () { err && err(); };
        document.head.appendChild(s);
    }

    window.loadPdfAndEmbed = function (path, selector, name) {
        if (!path) return;
        path = path.replace(/^~/, '');

        function embed() {
            try {
                if (typeof PDFObject !== 'undefined' && PDFObject.supportsPDFs) {
                    PDFObject.embed(path, selector);
                    if (name && window.jQuery) jQuery('#newsname').text(name);
                    if (window.jQuery) jQuery('#lnkPopup').click();
                } else {
                    window.location.href = path;
                }
            } catch (e) {
                window.location.href = path;
            }
        }

        if (typeof PDFObject === 'undefined') {
            loadScriptOnce('/js/pdfobject/pdfobject.min.js', embed, function () { window.location.href = path; });
        } else {
            embed();
        }
    };
})(window, document);
