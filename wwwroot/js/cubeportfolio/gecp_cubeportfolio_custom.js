
function reInit() {

    var gridContainer = $('#grid-container');
    var filtersContainer = $('#filters-container');

    if (!gridContainer.length) return;

    // FULL CLEANUP before re-init
    if (gridContainer.data('cubeportfolio')) {
        gridContainer.cubeportfolio('destroy');
    }

    // Remove old filter handlers (VERY IMPORTANT)
    filtersContainer.off('.cbp');

    // Ensure visibility
    gridContainer.css({
        display: 'block',
        visibility: 'visible'
    });

    // INIT CubePortfolio (simple + stable)
    gridContainer.cubeportfolio({
        defaultFilter: '*',
        animationType: 'fadeOut',   // simple, filters-safe
        gapHorizontal: 10,
        gapVertical: 10,
        gridAdjustment: 'responsive',

        mediaQueries: [
            { width: 1600, cols: 4 },
            { width: 1200, cols: 4 },
            { width: 800, cols: 3 },
            { width: 500, cols: 2 },
            { width: 320, cols: 1 }
        ],

        caption: 'none',
        displayType: 'default'
    });

    // FILTER HANDLING (bind ONCE per init)
    filtersContainer.on('click.cbp', '.cbp-filter-item', function () {

        var me = $(this);

        if (me.hasClass('cbp-filter-item-active')) return;

        me.addClass('cbp-filter-item-active')
            .siblings()
            .removeClass('cbp-filter-item-active');

        gridContainer.cubeportfolio('filter', me.data('filter'));
    });

    // Activate counters safely
    gridContainer.cubeportfolio(
        'showCounter',
        filtersContainer.find('.cbp-filter-item')
    );

    // Force layout recalculation
    $(window).trigger('resize');
}


function destroyGrid() {

    var gridContainer = $('#grid-container');
    var filtersContainer = $('#filters-container');

    if (gridContainer.data('cubeportfolio')) {
        gridContainer.cubeportfolio('destroy');
    }

    // Remove all CubePortfolio-related handlers
    filtersContainer.off('.cbp');
}