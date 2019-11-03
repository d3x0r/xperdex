
MOREOPTS=-debug
export MOREOPTS

all .DEFAULT:
	make -C xperdex.classes
	make -C xperdex.core
	make -C xperdex.loader
	make -C xperdex.tasks
	make -C monosh/monosh
