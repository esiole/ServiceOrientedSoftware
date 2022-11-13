FROM node:18-alpine
WORKDIR /src
COPY package.json /src/package.json
RUN npm install
COPY . /src
EXPOSE  3000
CMD [ "npm", "start" ]