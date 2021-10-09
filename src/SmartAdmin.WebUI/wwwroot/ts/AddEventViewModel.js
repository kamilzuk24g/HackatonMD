/// <reference path="typings/knockout.d.ts" />
/// <reference path="Tools.ts" />
var AddEvent;
(function (AddEvent) {
    var AddEventViewModel = /** @class */ (function () {
        function AddEventViewModel() {
            this.eventName = ko.observable("");
            this.eventPlace = ko.observable("");
            this.eventDescription = ko.observable("");
            this.eventDates = ko.observableArray([]);
            this.eventDates.push(new EventDate());
            this.proposedParticipants = ko.observableArray([]);
            this.selectedProposedParticipants = ko.observableArray([]);
            this.confirmedParticipants = ko.observableArray([]);
            this.proposedParticipantName = ko.observable("");
            this.estimatedCost = ko.observable("");
            this.tags = ko.observableArray([]);
            this.tag = ko.observable("");
            var currentUserText = document.getElementById("hdfCurrentUser").textContent;
            this.currentUser = ko.observable(currentUserText);
        }
        AddEventViewModel.prototype.onSaveClick = function () {
            var serverViewModel = SaveEventServerModel.fromAddEventViewModel(this);
            var serializedServerViewModel = JSON.stringify(serverViewModel);
            var request = new XMLHttpRequest();
            request.open("POST", "SaveEvent");
            request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
            request.onreadystatechange = function () {
                if (request.readyState == 4 && request.status == 200) {
                    window.location.href = "/eventovo/details?id=" + request.responseText;
                }
            };
            request.send(serializedServerViewModel);
        };
        AddEventViewModel.prototype.onAddDate = function () {
            this.eventDates.push(new EventDate());
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
            addEventViewModel.tags.remove(item);
        };
        AddEventViewModel.prototype.onAddMeClick = function () {
            if (this.confirmedParticipants.indexOf(this.currentUser()) === -1) {
                this.confirmedParticipants.push(this.currentUser());
            }
        };
        return AddEventViewModel;
    }());
    AddEvent.AddEventViewModel = AddEventViewModel;
    var EventDate = /** @class */ (function () {
        function EventDate() {
            this.eventDateString = ko.observable("");
            this.eventTimeString = ko.observable("");
        }
        return EventDate;
    }());
    var SaveEventServerModel = /** @class */ (function () {
        function SaveEventServerModel() {
        }
        SaveEventServerModel.fromAddEventViewModel = function (viewModel) {
            var result = new SaveEventServerModel();
            result.EventName = viewModel.eventName();
            result.EventPlace = viewModel.eventPlace();
            result.EventDescription = viewModel.eventDescription();
            result.EventDates = [];
            for (var i = 0; i < viewModel.eventDates().length; i++) {
                result.EventDates.push({ EventDateString: viewModel.eventDates()[i].eventDateString(), EventTimeString: viewModel.eventDates()[i].eventTimeString() });
            }
            result.ProposedParticipants = viewModel.proposedParticipants();
            result.ConfirmedParticipants = viewModel.confirmedParticipants();
            result.EstimatedCost = viewModel.estimatedCost();
            result.Tags = viewModel.tags();
            return result;
        };
        return SaveEventServerModel;
    }());
})(AddEvent || (AddEvent = {}));
var formElement = document.getElementById("frmMain");
var addEventViewModel = new AddEvent.AddEventViewModel();
ko.applyBindings(addEventViewModel, formElement);
//# sourceMappingURL=AddEventViewModel.js.map