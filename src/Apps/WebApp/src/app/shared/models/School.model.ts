import { LocationModel } from './Location.model';

export class SchoolModel {
    id: string;
    name: string;
    code: string;
    website: string;
    coverUrl: string;
    studentCount: number;
    tuiTion: number;
    description: string;
    schoolType: number;
    location: LocationModel;
}
