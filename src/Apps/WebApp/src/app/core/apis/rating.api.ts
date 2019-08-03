export class RatingApi {
    public static getRatingApi(schoolId: string) {
        return `api/v1/ratings?schoolId=${schoolId}`;
    }
}
