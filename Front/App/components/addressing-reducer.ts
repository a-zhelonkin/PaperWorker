import {combineReducers} from "redux";
import {ActionType, getType} from "typesafe-actions";
import * as addressingActions from "./addressing-actions";
import {AddressModel} from "../api/addresses-api";
import {StructureModel} from "../api/structures-api";
import {StreetModel} from "../api/streets-api";
import {LocalityModel} from "../api/localities-api";
import {TerritoryModel} from "../api/territories-api";

export type AddressingAction = ActionType<typeof addressingActions>;

export type AddressingState = Readonly<{
    addresses: AddressModel[];
    structures: StructureModel[];
    streets: StreetModel[];
    localities: LocalityModel[];
    territories: TerritoryModel[];
}>;

export default combineReducers<AddressingState, AddressingAction>({
    addresses: (addresses: AddressModel[] = [], action: any) => {
        switch (action.type) {
            case getType(addressingActions.addAddress):
                return [...addresses, action.payload];
            case getType(addressingActions.updateAddresses):
                return action.payload;
            default:
                return addresses;
        }
    },
    structures: (structures: StructureModel[] = [], action: any) => {
        switch (action.type) {
            case getType(addressingActions.addStructure):
                return [...structures, action.payload];
            case getType(addressingActions.updateStructures):
                return action.payload;
            default:
                return structures;
        }
    },
    streets: (streets: StreetModel[] = [], action: any) => {
        switch (action.type) {
            case getType(addressingActions.addStreet):
                return [...streets, action.payload];
            case getType(addressingActions.updateStreets):
                return action.payload;
            default:
                return streets;
        }
    },
    localities: (localities: LocalityModel[] = [], action: any) => {
        switch (action.type) {
            case getType(addressingActions.addLocality):
                return [...localities, action.payload];
            case getType(addressingActions.updateLocalities):
                return action.payload;
            default:
                return localities;
        }
    },
    territories: (territories: TerritoryModel[] = [], action: any) => {
        switch (action.type) {
            case getType(addressingActions.addTerritory):
                return [...territories, action.payload];
            case getType(addressingActions.updateTerritories):
                return action.payload;
            default:
                return territories;
        }
    }
});