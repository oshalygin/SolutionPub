module app.tweets {

    "use strict";

    interface ITweetsController {
        tweetsToDisplay: number;
    }

    class TweetsController implements ITweetsController {
        tweetsToDisplay: number;

        constructor() {

            var vm = this;
            vm.tweetsToDisplay = 3;

        }
    }

    angular.module("app.tweets")
        .controller("app.tweets.TweetsController",
        TweetsController);
}