export class EducationProgramApi {
    public static getProgramsApi() {
        return `api/v1/EducationPrograms`;
    }

    public static getProgramApi(id: string) {
        return `api/v1/EducationPrograms/${id}`;
    }
}
