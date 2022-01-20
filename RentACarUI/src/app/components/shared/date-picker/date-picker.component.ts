import { Input, Output, EventEmitter, Component } from '@angular/core';
import { formatDate } from '@angular/common';

@Component({
    templateUrl: './date-picker.component.html',
    selector: 'date-picker',
})
export class DatePickerComponent {
    @Output()
    public dateChange: EventEmitter<Date> = new EventEmitter<Date>();
    @Input() minDate: string;
    @Input()
    public set date(value: Date) {
        this._date = value;
        this.dateChange.emit(this._date);
    }

    public get date(): Date {
        return this._date;
    }

    private _date: Date;

    public set dateString(value: string) {
        this._dateString = value;
        this.date = new Date(value);
    }

    public get dateString(): string {
        this._dateString = this.formatDate(this.date);
        return this._dateString;
    }

    private _dateString: string;

    private formatDate(date: Date): string {
        return formatDate(date, 'yyyy-MM-dd', 'en');
    }
}