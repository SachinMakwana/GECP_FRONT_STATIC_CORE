function openTab(evt, tabId) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(tabId).style.display = "block";
    evt.currentTarget.className += " active";
}

// Get the element with id="defaultOpen" and click on it
if (document.getElementById("defaultOpen") != null) { document.getElementById("defaultOpen").click(); }

$(function () {

    $("#VideoCarousel").owlCarousel({
        singleItem: true,
        responsive: true,
        navigation: true,
        navigationText: ["<", ">"],
        pagination: false,
        slideSpeed: 1500,
        paginationSpeed: 2000,
        rewindSpeed: 2500
    });
    $("#AlumniCarousel").owlCarousel({
        singleItem: true,
        responsive: true,
        navigation: true,
        navigationText: ["<", ">"],
        pagination: false,
        slideSpeed: 1500,
        paginationSpeed: 2000,
        rewindSpeed: 2500
    });
});

// Horizontal Tab Switcher for Notice Board
function switchNoticeTab(event, tabId) {
    // 1. Hide all tab panes inside the component container boundary
    $('.notice-tab-pane').removeClass('active');

    // 2. Remove active highlight state from all navigation link button items
    $('.notice-tab-btn').removeClass('active');

    // 3. Show the targeted tab window element panel lane block
    $('#' + tabId).addClass('active');

    // 4. Highlight the currently clicked button element target node
    $(event.currentTarget).addClass('active');

    // 💡 CRUCIAL OWL RE-INITIALIZER HOOK:
    // When switching back to updates, Owl Carousel needs an offset refresh event to fix its grid sizing cache
    if (tabId === 'tab-updates') {
        var owl = $("#VideoCarousel").data('owlCarousel');
        if (owl) {
            owl.updateVars();
        }
    }
}
