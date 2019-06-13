import ApiBase from "./api-base";
import {AddressModel} from "./addresses-api";

export interface StructureModel {
    readonly id?: string;
    readonly number: number;
    readonly alone: boolean;
    readonly streetId: string;
    readonly addresses?: AddressModel[];
}

export default class StructuresApi extends ApiBase {

    public static getById(id: string): Promise<StructureModel> {
        return ApiBase.getAuthorizedApi(`structures?id=${id}`);
    }

    public static getByStreetId(streetId: string): Promise<StructureModel[]> {
        return ApiBase.getAuthorizedApi(`structures/getByStreetId?streetId=${streetId}`);
    }

    public static post(model: StructureModel): Promise<StructureModel> {
        return ApiBase.postAuthorizedApi(`structures`, model);
    }

}