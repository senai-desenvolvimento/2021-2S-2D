import axios from 'axios';

const api = axios.create({
  baseURL: 'http://192.168.6.203:5000/api',
});

export default api;
