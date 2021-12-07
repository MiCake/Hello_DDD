import { ApiRequestMethod } from '@/common/request';
import * as model from '@/models/apiModels';
import moment from 'moment';
import { BaseServices } from '../baseServices';

export default class MassageScheduleServices extends BaseServices {
    public get subUrl(): string {
        return `${this.baseUrl}/reserve-api/schedules`;
    }
    public get url(): string {
        return `${this.baseUrl}/reserve-api/schedules`;
    }

    public getTodaySchedules(day: Date) {
        return this.request.delayRequest<model.MassageScheduleDto[]>(`${this.subUrl}/teachnicians/1`, ApiRequestMethod.Get, { day: day.toISOString() });
    }

    public reserveCurrentSchedule(scheduleId: number, arrivalTime: moment.Moment) {
        return this.request.delayRequest<boolean>(`${this.subUrl}/${scheduleId}/reserve`, ApiRequestMethod.Post, {
            arrivalTime: arrivalTime,
            customerId: 1
        });
    }
}