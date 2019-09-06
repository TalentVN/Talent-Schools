export class EducationProgramApi {
    public static getProgramsApi() {
        return `api/v1/EducationPrograms`;
    }

    public static getPagingProgramsApi(currentPage: number) {
        return `api/v1/EducationPrograms/Page/${currentPage}`;
    }

    public static getProgramApi(id: string) {
        return `api/v1/EducationPrograms/${id}`;
    }

    public static changeActiveProgramApi(id: string) {
        return `api/v1/EducationPrograms/ChangeActive/${id}`;
    }
}
