//todo: refactor this into a typescript file and find a good home for it.
angular.module('stateMock', []);
angular.module('stateMock').service("$state", function(){
    this.expectedTransitions = [];
    this.transitionTo = function (stateName) {
        if (this.expectedTransitions.length > 0) {
            var expectedState = this.expectedTransitions.shift();
            if (expectedState !== stateName) {
                throw Error("Expected transition to state: " + expectedState + " but transitioned to " + stateName);
            }
        } else {
            throw Error("No more transitions were expected!");
        }
        console.log("Mock transition to: " + stateName);
    };

    this.expectTransitionTo = function (stateName) {
        this.expectedTransitions.push(stateName);
    };


    this.ensureAllTransitionsHappened = function () {
        if (this.expectedTransitions.length > 0) {
            throw Error("Not all transitions happened!");
        }
    };
});