FILES=$(find Assets | grep cs$ | grep -v 'QuickUnityTools' | grep -v 'tojam11')
set -x
uncrustify -c ./uncrustify.cfg --no-backup $FILES
