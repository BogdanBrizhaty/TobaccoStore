app.directive('productPaging', ['$location', function ($location) {
    return {
        restrict: 'E',
        scope: true,
        link: (scope, element) => {
            var pagesAmountToDisplay = 10;

            var template = '<ul class="pagination">' +
            '<li ng-repeat="pageNum in pages"' +
            'ng-class="pageNum == currentPage ? \'active\' : \'\'">' +
            '<a ng-click="goToPage(pageNum)"><span>{{pageNum}}</span></a></li>' +
            '</ul>';


            var getPages = (curPage) => {
                var tmp = [];
                if (scope.totalItems < 9) {
                    return [1];
                }
                //console.log('curPage ' + curPage);
                //console.log('pagesAmountToDisplay ' + pagesAmountToDisplay);
                //console.log('Math.ceil  ' + (Math.ceil(curPage / pagesAmountToDisplay) * pagesAmountToDisplay - pagesAmountToDisplay + 1));
                var startAt = Math.ceil(curPage / pagesAmountToDisplay) * pagesAmountToDisplay - pagesAmountToDisplay + 1;
                console.log('st ' + startAt);
                //if (startAt + pagesAmountToDisplay - 1 > scope.totalPages) {
                //    if (scope.totalPages - scope.pages[pagesAmountToDisplay - 1] == 0)
                //        return scope.pages;
                //    for (var i = startAt - pagesAmountToDisplay + 1; i < startAt + pagesAmountToDisplay && i <= scope.totalPages; i += scope.totalPages - scope.pages[pagesAmountToDisplay - 1]) {
                //        console.log(scope.totalPages - scope.pages[pagesAmountToDisplay - 1]);
                //        tmp.push(i);
                //    }
                //    return tmp;
                //}
                for (var i = startAt; i < startAt + pagesAmountToDisplay && i <= scope.totalPages; i++)
                    tmp.push(i);
                return tmp;
            }

            scope.$watch('totalItems', (value, old) => {
                scope.pages = getPages(scope.currentPage);

                element.html(template);

                if (scope.totalPages == 1)
                    element.html('');
            });




        }
    };
}]);