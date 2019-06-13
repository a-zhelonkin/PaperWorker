import ApiBase from "./api-base";
import {LocalityModel} from "./localities-api";

export interface TerritoryModel {
    readonly id?: string;
    readonly name: string;
    readonly parentId?: string;
    readonly localities?: LocalityModel[];
    readonly children?: TerritoryModel[];
}

export default class TerritoriesApi extends ApiBase {

    public static getById(id: string): Promise<TerritoryModel> {
        return ApiBase.getAuthorizedApi(`territories?id=${id}`);
    }

    public static getByParentId = (parentId?: string): Promise<TerritoryModel[]> => parentId
        ? ApiBase.getAuthorizedApi(`territories/getByParentId?parentId=${parentId}`)
        : ApiBase.getAuthorizedApi("territories/getByParentId")

    public static post(model: TerritoryModel): Promise<TerritoryModel> {
        return ApiBase.postAuthorizedApi("territories", model);
    }

}