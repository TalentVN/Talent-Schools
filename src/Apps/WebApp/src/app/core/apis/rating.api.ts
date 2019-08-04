export class RatingApi {
    public static createRatingApi() {
        return `api/v1/ratings`;
    }

    public static getRatingApi(schoolId: string) {
        return `api/v1/ratings?schoolId=${schoolId}`;
    }
}
