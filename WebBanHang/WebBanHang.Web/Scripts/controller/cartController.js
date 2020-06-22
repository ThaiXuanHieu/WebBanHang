var cartController = {

    init: function () {
        cartController.loadYourCart();
        cartController.registerEvent();
    },

    registerEvent: function () {
        $('.btn-see-more').off('click').on('click', function () {

        });

        $('.btn-buynow').off('click').on('click', function () {

        });
    }

}

cartController.init();