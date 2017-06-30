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

app.controller('storyList', function ($location, $scope, storyApi) {
    $scope.NewStoryController = asm;
    storyApi.getStories().then(function (data) {
        $scope.stories = data.data;
    });

    $scope.$on("storyAdded", function (event, story) {
        $scope.stories.push(story);

    })

    $scope.editStory = function (story) {
        $location.path('/edit/' + story.Id);
    };
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
