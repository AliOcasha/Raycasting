import pygame as pg
pg.init()

WIN_WIDTH = 600
WIN_HEIGHT = 600

class Ray:
    pass

class Boundary:
    pass

def main():
    Run = True
    screen = pg.display.set_mode((WIN_WIDTH, WIN_HEIGHT))
    clock = pg.time.Clock()

    while Run:
        clock.tick(30)
        for event in pg.event.get():
            if event.type == pg.QUIT:
                Run = False
                pg.quit()
                sys.exit(0)
        pg.display.update()

main()
