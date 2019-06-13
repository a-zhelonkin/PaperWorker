import ApiBase from "./api-base";

export interface AddressModel {
    readonly number: number;
    readonly structureId: string;
}

export default class AddressesApi extends ApiBase {

    public static get(structureId: string): Promise<AddressModel[]> {
        return ApiBase.getAuthorizedApi(`addresses?structureId=${structureId}`);
    }

    public static post(model: AddressModel): Promise<AddressModel> {
        return ApiBase.postAuthorizedApi(`addresses`, model);
    }

}