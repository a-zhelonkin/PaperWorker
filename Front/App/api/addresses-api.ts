import ApiBase from "./api-base";

export interface AddressModel {
    readonly id?: string;
    readonly number: number;
    readonly structureId: string;
    readonly consumers?: any[];
}

export default class AddressesApi extends ApiBase {

    public static getById(id: string): Promise<AddressModel> {
        return ApiBase.getAuthorizedApi(`addresses?id=${id}`);
    }

    public static getByStructureId(structureId: string): Promise<AddressModel[]> {
        return ApiBase.getAuthorizedApi(`addresses/getByStructureId?structureId=${structureId}`);
    }

    public static post(model: AddressModel): Promise<AddressModel> {
        return ApiBase.postAuthorizedApi(`addresses`, model);
    }

}