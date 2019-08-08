export class RatingApi {
    public static createRatingApi() {
        return `api/v1/ratings`;
    }

    public static getRatingApi(schoolId: string) {
        return `api/v1/ratings?schoolId=${schoolId}`;
    }

    public static queryRatingApi(schoolId: string, ratingType: number) {
        return `api/v1/ratings/query?schoolId=${schoolId}&ratingType=${ratingType}`;
    }
}
