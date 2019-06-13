import ApiBase from "./api-base";

export interface StructureModel {
    readonly id?: string;
    readonly number: number;
    readonly alone: boolean;
    readonly streetId: string;
}

export default class StructuresApi extends ApiBase {

    public static get(streetId: string): Promise<StructureModel[]> {
        return ApiBase.getAuthorizedApi(`structures?streetId=${streetId}`);
    }

    public static post(model: StructureModel): Promise<StructureModel> {
        return ApiBase.postAuthorizedApi(`structures`, model);
    }

}