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