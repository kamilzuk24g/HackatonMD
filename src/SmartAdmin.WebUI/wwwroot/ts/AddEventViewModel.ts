/// <reference path="typings/knockout.d.ts" />
/// <reference path="Tools.ts" />

namespace AddEvent {
    export class AddEventViewModel {
        public eventName: KnockoutObservable<string>;
        public eventPlace: KnockoutObservable<string>;
        public eventDescription: KnockoutObservable<string>;
        public eventDateString: KnockoutObservable<string>;
        public eventTimeString: KnockoutObservable<string>;
        public proposedParticipants: KnockoutObservableArray<string>;
        public selectedProposedParticipants: KnockoutObservableArray<string>;
        public confirmedParticipants: KnockoutObservableArray<string>;
        public proposedParticipantName: KnockoutObservable<string>;
        public estimatedCost: KnockoutObservable<string>;
        public tags: KnockoutObservableArray<string>;
        public tag: KnockoutObservable<string>;
        public currentUser: KnockoutObservable<string>;
        
        constructor() {
            this.eventName = ko.observable<string>("");
            this.eventPlace = ko.observable<string>("");
            this.eventDescription = ko.observable<string>("");
            this.eventDateString = ko.observable<string>("");
            this.eventTimeString = ko.observable<string>("");
            this.proposedParticipants = ko.observableArray<string>([]);
            this.selectedProposedParticipants = ko.observableArray<string>([]);
            this.confirmedParticipants = ko.observableArray<string>([]);
            this.proposedParticipantName = ko.observable<string>("");
            this.estimatedCost = ko.observable<string>("");
            this.tags = ko.observableArray<string>([]);
            this.tag = ko.observable<string>("");
            
            let currentUserText = document.getElementById("hdfCurrentUser").textContent;
            this.currentUser = ko.observable<string>(currentUserText);
        }
        
        public onSaveClick(): void {
            let serverViewModel: SaveEventServerModel = SaveEventServerModel.fromAddEventViewModel(this);
            let serializedServerViewModel = JSON.stringify(serverViewModel);
            let request = new XMLHttpRequest();
            request.open("POST", "SaveEvent");
            request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
            request.onreadystatechange = function()
                {
                    if(request.readyState == 4 && request.status == 200)
                    {
                        window.location.href = `/eventovo/details?id=${request.responseText}`;
                    }
                }
                
            request.send(serializedServerViewModel); 
        }
        
        public onTagAddClick(): void {
            if (IsNullUndefinedOrEmpty(this.tag())) {
                return;
            }
            
            this.tags.push(this.tag());
            this.tag("");
        }
        
        public onAddProposedParticipantClick(): void {
            if (IsNullUndefinedOrEmpty(this.proposedParticipantName())) {
                return;
            }
            
            this.proposedParticipants.push(this.proposedParticipantName());
            this.proposedParticipantName("");
        }
        
        public onRemoveProposedParticipantsClick(): void {
            for (let participant of this.selectedProposedParticipants()) {
                this.proposedParticipants.remove(participant);
            }
        }
        
        public onTagClick(item: any, event: any): void {
            addEventViewModel.tags.remove(item);
        }
        
        public onAddMeClick(): void {
            if (this.confirmedParticipants.indexOf(this.currentUser()) === -1) {
                this.confirmedParticipants.push(this.currentUser());
            }
        }
    }
    
    class SaveEventServerModel {
        public EventName: string;
        public EventPlace: string;
        public EventDescription: string;
        public EventDateString: string;
        public EventTimeString: string;
        public ProposedParticipants: string[];
        public ConfirmedParticipants: string[];
        public EstimatedCost: string;
        public Tags: string[];
        
        static fromAddEventViewModel(viewModel: AddEventViewModel): SaveEventServerModel {
            let result = new SaveEventServerModel();
            result.EventName = viewModel.eventName();
            result.EventPlace = viewModel.eventPlace();
            result.EventDescription = viewModel.eventDescription();
            result.EventDateString = viewModel.eventDateString();
            result.EventTimeString = viewModel.eventTimeString();
            result.ProposedParticipants = viewModel.proposedParticipants();
            result.ConfirmedParticipants = viewModel.confirmedParticipants();
            result.EstimatedCost = viewModel.estimatedCost();
            result.Tags = viewModel.tags();
            
            return result;
        }
    }
}

let formElement = document.getElementById("frmMain");
let addEventViewModel = new AddEvent.AddEventViewModel();
ko.applyBindings(addEventViewModel, formElement);
