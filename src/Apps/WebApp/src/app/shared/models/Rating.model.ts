export class RatingModel {
    id: string;
    comment: string;
    ratingType: number;
    value: number;
    userId: string;
    schoolId: string;
    createdDate: Date;
}

export class RatingUserModel {
    id: string;
    firstName: string;
    lastName: string;
}

