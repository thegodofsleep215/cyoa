var asm = function ($uibModal, $scope, storyApi) {
    var $ctrl = this;

    $ctrl.add = function () {
        var modalIntance = $uibModal.open({
            ariaLabeledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: './scripts/templates/addStoryModal.html',
            controller: 'AddStoryController',
            controllerAs: '$ctrl',
        });

        modalIntance.result.then(function (story) {
            storyApi.insertStory(story).then(function (result) {
                storyApi.getStory(result.data).then(function (result) {
                    $scope.$emit("storyAdded", story);
                })
            })

        });
    }
};

app.controller('storyList', function ($scope, storyApi) {
    $scope.NewStoryController = asm;
    storyApi.getStories().then(function (data) {
        $scope.stories = data.data;
    });

    $scope.$on("storyAdded", function (event, story) {
        $scope.stories.push(story);

    })
});
app.controller("AddStoryController", function ($uibModalInstance) {
    var $ctrl = this;
    var title = "";
    var author = "";

    $ctrl.ok = function () {
        $uibModalInstance.close({
            Title: $ctrl.title,
            Author: $ctrl.author,
        });
    };

    $ctrl.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

});
app.factory("storyApi", ["$http", function ($http) {
    return {
        getStories: function () {
            return $http.get('/Story');
        },
        getStory: function (id) {
            return $http.get('/Story/' + id);
        },
        insertStory: function (story) {
            return $http.post('/Story/', story);
        },
        updateStory: function (story) {
            return $http.put('/Story/', story);
        }
    };
}]);