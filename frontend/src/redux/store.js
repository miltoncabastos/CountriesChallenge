import { createStore } from 'redux';
import Reducer from './rootReducer';

export const store = createStore(Reducer);