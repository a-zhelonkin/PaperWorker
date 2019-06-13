import ApiBase from "./api-base";
import {StructureModel} from "./structures-api";

export interface StreetModel {
    readonly id?: string;
    readonly name: string;
    readonly localityId: string;
    readonly structures?: StructureModel[];
}

export default class StreetsApi extends ApiBase {

    public static getById(id: string): Promise<StreetModel> {
        return ApiBase.getAuthorizedApi(`streets?id=${id}`);
    }

    public static getByLocalityId(localityId: string): Promise<StreetModel[]> {
        return ApiBase.getAuthorizedApi(`streets/getByLocalityId?localityId=${localityId}`);
    }

    public static post(model: StreetModel): Promise<StreetModel> {
        return ApiBase.postAuthorizedApi(`streets`, model);
    }

}