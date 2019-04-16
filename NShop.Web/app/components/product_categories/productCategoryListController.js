(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        $scope.getProductCategories = getProductCategories;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.selectAll = selectAll;

        $scope.deleteMulti = deleteMulti;
        function deleteMulti() {
            var lstId = [];
            $.each($scope.selected, function (i, item) {
                lstId.push(item.ID);
            });
            $ngBootbox.confirm('Bạn có chắc chắn xóa không').then(function () {
                var config = {
                    params: {
                        checkedProductCategories: JSON.stringify(lstId)
                    }
                };
                apiService.del('api/productcategory/deletemulti', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                    $scope.getProductCategories();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công');
                });
            });
           
        }
        $scope.isAll = false;
        function selectAll() {           
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        //theo dõi sự kiện check
        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc chắn xóa').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                };
                apiService.del('api/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    $scope.getProductCategories();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                });
            });
        }

        function search() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 5
                }
            };

            apiService.get('api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning("Không tìm thấy bản ghi nào");
                }
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product categories failed.');
            });
        }

        $scope.getProductCategories();
    }
})(angular.module('nshop.product_categories'));