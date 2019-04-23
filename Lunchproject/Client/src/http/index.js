import Axios from 'axios'

import constants from '../constants'

export default Axios.create({
  baseURL: constants.API_URL,
  headers: {
    "Access-Control-Allow-Origin": constants.API_URL
  },
  timeout: 20000
});