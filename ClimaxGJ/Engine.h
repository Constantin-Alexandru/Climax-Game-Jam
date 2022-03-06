#pragma once

#include <SDL.h>
#include <SDL_image.h>

#include <iostream>
#include <vector>

#include "Connection.h"
#include "TextureManager.h"
#include "NetworkComponent.h"

class Engine {

public:
	
	Engine();
	~Engine();

	void init(int x, int y, int width, int height, bool fullscreen);
	
	void handleEvents();
	void update();
	void render();
	void clean();

	bool running() { return isRunning; };

public:

	static std::vector<GameObject*> gameObjects;

	static Connection unlinkedConnection;

private:

	void checkCollisionObjects(Vector2D_f mousePos);

private:

	SDL_Window* window = NULL;
	SDL_Renderer* renderer = NULL;

	bool isRunning = false;
};