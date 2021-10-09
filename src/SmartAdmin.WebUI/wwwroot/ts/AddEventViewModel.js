/// <reference path="typings/knockout.d.ts" />
/// <reference path="Tools.ts" />
var AddEvent;
(function (AddEvent) {
    var AddEventViewModel = /** @class */ (function () {
        function AddEventViewModel() {
            this.eventName = ko.observable("");
            this.eventPlace = ko.observable("");
            this.eventDescription = ko.observable("");
            this.eventDateString = ko.observable("");
            this.eventTimeString = ko.observable("");
            this.proposedParticipants = ko.observableArray([]);
            this.selectedProposedParticipants = ko.observableArray([]);
            this.confirmedParticipants = ko.observableArray([]);
            this.proposedParticipantName = ko.observable("");
            this.estimatedCost = ko.observable("");
            this.tags = ko.observableArray([]);
            this.tag = ko.observable("");
        }
        AddEventViewModel.prototype.onSaveClick = function () {
            alert("aaa");
        };
        AddEventViewModel.prototype.onTagAddClick = function () {
            if (IsNullUndefinedOrEmpty(this.tag())) {
                return;
            }
            this.tags.push(this.tag());
            this.tag("");
        };
        AddEventViewModel.prototype.onAddProposedParticipantClick = function () {
            if (IsNullUndefinedOrEmpty(this.proposedParticipantName())) {
                return;
            }
            this.proposedParticipants.push(this.proposedParticipantName());
            this.proposedParticipantName("");
        };
        AddEventViewModel.prototype.onRemoveProposedParticipantsClick = function () {
            for (var _i = 0, _a = this.selectedProposedParticipants(); _i < _a.length; _i++) {
                var participant = _a[_i];
                this.proposedParticipants.remove(participant);
            }
        };
        AddEventViewModel.prototype.onTagClick = function (item, event) {
            //this.proposedParticipants.remove(event.target.textContent);
        };
        return AddEventViewModel;
    }());
    AddEvent.AddEventViewModel = AddEventViewModel;
})(AddEvent || (AddEvent = {}));
var formElement = document.getElementById("frmMain");
ko.applyBindings(new AddEvent.AddEventViewModel(), formElement);
//# sourceMappingURL=AddEventViewModel.js.map