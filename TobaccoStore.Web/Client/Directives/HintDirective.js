app.directive('isInCartHint', function () {
    return {
        restrict: 'E',
        scope: true,
        link: function (scope, element) {
            var template = '';
            if (scope.isInCart(scope.product.Id))
                template = '<span class="add-to-cart half-opacity" style="cursor: default;">Добавлен</span>';
            else
                template = '<span class="add-to-cart-unactive">&nbsp;</span>';
            element.html(template);
            
        }
    }
})