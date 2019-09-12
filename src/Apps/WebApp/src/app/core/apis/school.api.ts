export class SchoolApi {
    public static getSchoolsApi(): string {
        return 'api/v1/Schools';
    }

    public static getPagingSchoolsApi(currentPage: number): string {
        return `api/v1/Schools?currentPage=${currentPage}`
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

    public static searchSchoolsApi() {
        return `api/v1/Schools/Search`;
    }
}
