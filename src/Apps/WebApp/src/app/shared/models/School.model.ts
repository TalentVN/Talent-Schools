import { LocationModel } from './Location.model';
import { MajorModel } from './Major.model';
import { ProgramModel } from './Program.model';
import { CreateRatingModel } from './CreateRating.model';

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
    ratingCount: number;
    majors: MajorModel[];
    programs: ProgramModel[];
    ratings: CreateRatingModel[];
}
