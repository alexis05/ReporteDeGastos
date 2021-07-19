import axios from 'axios'

const isHandlerEnabled = (config = {}) => {
  return config.hasOwnProperty('handlerEnabled') && !config.handlerEnabled
    ? false
    : true
}

const requestHandler = (request) => {
  return request
}

let axiosInstance = axios.create({
  baseURL: `http://localhost:5000/`,
})

if (process.env.NODE_ENV === 'development') {
  axiosInstance = axios.create({
    baseURL: `http://localhost:5000/`,
  })
} else if (process.env.NODE_ENV === 'production') {
  axiosInstance = axios.create({
    baseURL: `https://deliciasdaymar.com/`,
  })
} else {
  axiosInstance = axios.create({
    baseURL: `http://localhost:5000/`,
  })
}

axiosInstance.interceptors.request.use((request) => requestHandler(request))
axiosInstance.interceptors.response.use(
  (response) => {
    return response
  },
  (error) => {
    return error
  },
)

export default axiosInstance
