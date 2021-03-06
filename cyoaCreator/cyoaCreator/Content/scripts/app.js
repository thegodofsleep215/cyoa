﻿var app = angular.module("StoryListModule", ["ui.bootstrap", "ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "scripts/templates/storyList.html"
        })
        .when("/edit/:id", {
            templateUrl: "scripts/templates/storyEdit.html"
        });
});
