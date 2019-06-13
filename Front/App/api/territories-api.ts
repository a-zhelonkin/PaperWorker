import ApiBase from "./api-base";

export interface TerritoryModel {
    readonly id?: string;
    readonly name: string;
    readonly parentId?: string;
}

export default class TerritoriesApi extends ApiBase {

    public static get = (parentId?: string): Promise<TerritoryModel[]> => parentId
        ? ApiBase.getAuthorizedApi(`territories?parentId=${parentId}`)
        : ApiBase.getAuthorizedApi("territories")

    public static post(model: TerritoryModel): Promise<TerritoryModel> {
        return ApiBase.postAuthorizedApi("territories", model);
    }

}