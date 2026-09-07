# About these workflows

These are Gitea Actions definitions, not GitHub Actions. They were written for the
course instructor's own Gitea instance (`gidsik-dev.ru`) and are kept here only as
part of the coursework record — nothing in this repository runs them.

`laba7-build.yaml` originally carried a plain-text FTP password for that instance.
It has been redacted from the whole history. **The credential itself must be
treated as compromised and rotated by the owner of that server**: it was publicly
readable from 8 May 2024, and removing it from git does not revoke it. Old commits
also stay reachable through GitHub's pull-request refs until GitHub Support purges
them.
