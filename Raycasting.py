import pygame as pg
import sys
import math

import Objects
import Collision
pg.init()

WIN_WIDTH = 900
WIN_HEIGHT = 900
STANDART_LENGTH = 100

def createWalls():
    Walls = [Objects.Boundary((200,150), (200,500)),
             Objects.Boundary((400,200), (250,200)),
             Objects.Boundary((300,700), (300,300)),
             Objects.Boundary((250,800), (650,800)),
             Objects.Boundary((200,150), (300,150)),
             Objects.Boundary((650,750), (750,600)),
             Objects.Boundary((600,200), (600,450)),
             Objects.Boundary((600,200), (650,200)),
             Objects.Boundary((650,200), (650,100)),
             Objects.Boundary((650,100), (300,100))]
    return Walls

def createRays():
    rays = [

            Objects.Ray(list((0.001,1))),
            Objects.Ray(list((0.001,0.5))),

            Objects.Ray(list((0.001,-1))),
            Objects.Ray(list((0.001,-0.5))),

            Objects.Ray(list((-1,0.001))),
            Objects.Ray(list((-0.5,0.001))),

            Objects.Ray(list((1,0.001))),
            Objects.Ray(list((0.5,0.001))),

            Objects.Ray(list((1,1))),
            Objects.Ray(list((0.5,1))),

            Objects.Ray(list((-1,-1))),
            Objects.Ray(list((-0.5,-1))),

            Objects.Ray(list((1,-1))),
            Objects.Ray(list((0.5,-1))),

            Objects.Ray(list((-1,1))),
            Objects.Ray(list((-1,0.5)))]    
    return rays   

def Draw_Window(screen, Rays, Boundaries):
    for B in Boundaries:
        B.draw(screen)

    for R in Rays:
        R.draw(screen)

    pg.display.update()
    
def main():
    Run = True
    screen = pg.display.set_mode((WIN_WIDTH, WIN_HEIGHT))
    clock = pg.time.Clock()

    Walls = createWalls()
    Rays = createRays()

    while Run:
        clock.tick(30)
        for event in pg.event.get():
            if event.type == pg.QUIT:
                Run = False
                pg.quit()
                sys.exit(0)
        # Update Ray Position and Intersection points
        for ray in Rays:
            Collision.checkIntersection(Walls,ray)

        #Draw
        Draw_Window(screen, Rays, Walls)

main()