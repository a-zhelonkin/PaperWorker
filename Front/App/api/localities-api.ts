import ApiBase from "./api-base";

export interface LocalityModel {
    readonly id?: string;
    readonly name: string;
    readonly territoryId: string;
}

export default class LocalitiesApi extends ApiBase {

    public static get(territoryId: string): Promise<LocalityModel[]> {
        return ApiBase.getAuthorizedApi(`localities?territoryId=${territoryId}`);
    }

    public static post(model: LocalityModel): Promise<LocalityModel> {
        return ApiBase.postAuthorizedApi(`localities`, model);
    }

}