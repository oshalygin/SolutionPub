module app.tweets {

    "use strict";

    interface ITweetsController {
        tweetsToDisplay: number;
    }

    class TweetsController implements ITweetsController {
        tweetsToDisplay: number;
        tweets: app.models.ITweet[];
        
        constructor() {

            var vm = this;
            vm.tweetsToDisplay = 4;

        }
    }

    angular.module("app.tweets")
        .controller("app.tweets.TweetsController",
        TweetsController);
}