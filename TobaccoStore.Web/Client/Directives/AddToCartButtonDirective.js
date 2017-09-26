app.directive('addToCartBtn', function () {

    return {
        restrict: 'E',
        scope: true,
        link: (scope, element) => {
            var template = '<a class="add-to-cart';
            var inCart = scope.isInCart(scope.product.Id);
            if (inCart)
                template += ' half-opacity">Убрать';
            else
                template += '">Добавить в корзину';

            template += '</a>'
            element.html(template);
        }
    }
});