FROM node:11

WORKDIR /app

# Add a user
RUN groupadd lanthir \
    && useradd -d /app -g lanthir lanthir \
    && chown -R lanthir:lanthir /app

USER lanthir

# Cache the dependencies
COPY package*.json ./
RUN npm install

# Copy the test of the sources
COPY . .

EXPOSE 8080

# Run the development server
ENTRYPOINT [ "npm", "run" ]
CMD [ "serve" ]
