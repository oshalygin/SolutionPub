module app.tweets {

    "use strict";

    interface ITweetsController {
        tweetsToDisplay: number;
    }

    class TweetsController implements ITweetsController {
        tweetsToDisplay: number;
        tweets: app.models.ITweet[];


        static $inject = ["twitterService"];
        constructor(twitterService: app.services.TwitterService) {

            var vm = this;
            vm.tweetsToDisplay = 3;
            twitterService.getTweets()
                .then((data: any) => {
                    vm.tweets = data;
                    console.log(vm.tweets);
                });

        }
    }

    angular.module("app.tweets")
        .controller("app.tweets.TweetsController",
        TweetsController);
}