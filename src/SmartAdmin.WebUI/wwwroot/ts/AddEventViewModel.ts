/// <reference path="typings/knockout.d.ts" />

namespace AddEvent {
    export class AddEventViewModel {
        public eventName: KnockoutObservable<string>;
        public eventPlace: KnockoutObservable<string>;
        public eventDescription: KnockoutObservable<string>;
        public eventDateString: KnockoutObservable<string>;
        public eventTimeString: KnockoutObservable<string>;
        public proposedParticipants: KnockoutObservableArray<string>;
        public confirmedParticipants: KnockoutObservableArray<string>;
        public proposedParticipantName: KnockoutObservable<string>;
        public estimatedCost: KnockoutObservable<string>;
        public tags: KnockoutObservableArray<string>;
        public tag: KnockoutObservable<string>;
        
        constructor() {
            this.eventName = ko.observable<string>();
            this.eventPlace = ko.observable<string>();
            this.eventDescription = ko.observable<string>();
            this.eventDateString = ko.observable<string>();
            this.eventTimeString = ko.observable<string>();
            this.proposedParticipants = ko.observableArray<string>();
            this.confirmedParticipants = ko.observableArray<string>();
            this.proposedParticipantName = ko.observable<string>();
            this.estimatedCost = ko.observable<string>();
            this.tags = ko.observableArray<string>();
            this.tag = ko.observable<string>();
        }
        
        public onSaveClick(): void {
            alert("aaa");
        }
    }
}

let formElement = document.getElementById("frmMain");
ko.applyBindings(new AddEvent.AddEventViewModel(), formElement);
