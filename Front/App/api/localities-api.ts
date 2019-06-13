import ApiBase from "./api-base";
import {StreetModel} from "./streets-api";

export interface LocalityModel {
    readonly id?: string;
    readonly name: string;
    readonly territoryId: string;
    readonly streets?: StreetModel[];
}

export default class LocalitiesApi extends ApiBase {

    public static getById(id: string): Promise<LocalityModel> {
        return ApiBase.getAuthorizedApi(`localities?id=${id}`);
    }

    public static getByTerritoryId(territoryId: string): Promise<LocalityModel[]> {
        return ApiBase.getAuthorizedApi(`localities/getByTerritoryId?territoryId=${territoryId}`);
    }

    public static post(model: LocalityModel): Promise<LocalityModel> {
        return ApiBase.postAuthorizedApi(`localities`, model);
    }

}