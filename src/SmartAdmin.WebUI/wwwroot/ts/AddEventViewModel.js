/// <reference path="typings/knockout.d.ts" />
/// <reference path="Tools.ts" />
var AddEvent;
(function (AddEvent) {
    var AddEventViewModel = /** @class */ (function () {
        function AddEventViewModel() {
            this.eventName = ko.observable();
            this.eventPlace = ko.observable();
            this.eventDescription = ko.observable();
            this.eventDateString = ko.observable();
            this.eventTimeString = ko.observable();
            this.proposedParticipants = ko.observableArray();
            this.confirmedParticipants = ko.observableArray();
            this.proposedParticipantName = ko.observable();
            this.estimatedCost = ko.observable();
            this.tags = ko.observableArray();
            this.tag = ko.observable();
        }
        AddEventViewModel.prototype.onSaveClick = function () {
            alert("aaa");
        };
        AddEventViewModel.prototype.onTagAddClick = function () {
            if (IsNullUndefinedOrEmpty(this.tag())) {
                return;
            }
            this.tags().push(this.tag());
        };
        return AddEventViewModel;
    }());
    AddEvent.AddEventViewModel = AddEventViewModel;
})(AddEvent || (AddEvent = {}));
var formElement = document.getElementById("frmMain");
ko.applyBindings(new AddEvent.AddEventViewModel(), formElement);
