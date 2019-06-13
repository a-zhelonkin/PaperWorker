import ApiBase from "./api-base";

export interface StreetModel {
    readonly id?: string;
    readonly name: string;
    readonly localityId: string;
}

export default class StreetsApi extends ApiBase {

    public static get(localityId: string): Promise<StreetModel[]> {
        return ApiBase.getAuthorizedApi(`streets?localityId=${localityId}`);
    }

    public static post(model: StreetModel): Promise<StreetModel> {
        return ApiBase.postAuthorizedApi(`streets`, model);
    }

}