export class SchoolApi {
    public static getSchoolsApi(): string {
        return 'api/v1/Schools';
    }

    public static getSchoolApi(schoolId: string) {
        return `api/v1/Schools/${schoolId}`;
    }

    public static getSchoolMajorApi(schoolId: string) {
        return `api/v1/Schools/${schoolId}/majors`;
    }

    public static getSchoolProgarmApi(schoolId: string) {
        return `api/v1/Schools/${schoolId}/programs`;
    }
}
