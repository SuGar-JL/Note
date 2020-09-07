# Git基本操作
## 一、先有本地仓库（推送）
### 1. 新建本地仓库：
1. 选择一个盘或文件夹
   `cd /盘名/文件夹名`

2. 新建文件夹
   `mkdir directoryName`

3. 初始化目录为Git仓库

   `cd directoryName`

   `git init`

### 2.在本地仓库存文件：
1. 新建一个文件并初始化

   `echo "# learnGit" >> readme.md`

### 3.本地仓库进行文件的提交：
1. 提交文件
2. `git add readme.md`//到暂存区
   `git commit -m "fisrt commit"`//到git仓库

### 4.将本地仓库master分支内容推送到github的仓库：
1. 在github上新建一个空的仓库

2. 将本地仓库master分支推送到github仓库
3. `git remote add origin https://github.com/SuGar-JL/learnGit.git`//用的https协议
   或`git remote add origin git@github.com:SuGar-JL/learnGit.git`//用的ssh协议，比较快?
   `git push -u origin master`

4. 推送到远程仓库一次后，以后推送这样操作

   `git push origin master`//前提，本地仓库进行了文件的提交（add和commit）

## 二、先有远程（github）仓库（克隆）
1. 先在github上新建一个仓库，比如叫hello-world，事先在里面存东西，比如用README.md文件初始化它

2. git克隆hello-world仓库到本地（先选好一个存放的地儿，在该地执行命令）
3. `git clone https://github.com/SuGar-JL/hello-world.git`
   或`git clone git@github.com:SuGar-JL/hello-world.git`

## 三、分支管理
### 1.创建、合并与删除分支
1. 创建与切换分支

2. 分支的根是那个分支，要先切换到该分支，再创建其子分支，这样子分支才能得到其副本

   `git checkout -b branchName` （创建+切换）

   `git switch -c branchName`（创建+切换）//我的git没有

   `git branch branchName`（创建分支）

   `git checkout branchName`（切换分支）
   `git switch branchName>`（切换分支）//我的git没有

#### 		1.2 查看当前分支
1. `git branch`//列出所有分支，当前分支前面会标一个*号

#### 		1.3 合并分支
1. 在子分支工作完成，并进行提交后`git merge branchName`//合并指定分支到当前分支（master）中，需切换到当前分支执行命令，默认使用`Fast forward`模式切换到master后，去本地仓库看修改的文件，子分子的修改不见了，因为现在是主分支了，需合并后才能看到

#### 		1.3 删除分支
1. `git branch -d branchName`

### 2. 解决冲突
#### 		2.1 冲突的产生
1. 新建分支

2. 在新分支修改内容并提交

3. 切回master，此时没有进行合并操作

4. 在master也修改内容并提交

5. 合并，此时产生冲突

![image-20200728163557664](C:\Users\DELL\AppData\Roaming\Typora\typora-user-images\image-20200728163557664.png)

#### 		2.2 冲突的解决
1. 在master把子分支修改的东西添加上，再提交

2. 再次进行合并操作

3. 看分支合并图

​				`git log --graph`

![image-20200728164731746](C:\Users\DELL\AppData\Roaming\Typora\typora-user-images\image-20200728164731746.png)
### 3. 分支管理策略
#### 3.1 禁用`Fast forward`模式

1. 合并分支时，如果可能，Git会用`Fast forward`模式，但这种模式下，删除分支后，会丢掉分支信息。如果要强制禁用`Fastforward`模式，Git就会在merge时生成一个新的commit，这样，从分支历史上就可以看出分支信息。

2. 进行合并时接入参数`--no-ff`，此时会自动创建一个新的commit，需要处理，就再加上`-m "commit information"`。
3. `git merge --no-ff -m "merge with no-ff" branchName`

#### 3.2  分支策略

1. 不在master上干活，同组开发人员都在一个子分支上干活，比如dev，各自用的工作在dev的子分支上进行，完成后提交到dev，master是用来发布最后的dev的。

#### 3.3 Bug分支

##### 3.3.1 Git的`stach`功能

1. 软件开发中，bug就像家常便饭一样。有了bug就需要修复，在Git中，由于分支是如此的强大，所以，每个bug都可以通过一个新的临时分支来修复，修复后，合并分支，然后将临时分支删除。

   当你接到一个修复一个代号101的bug的任务时，很自然地，你想创建一个分支`issue-101`来修复它，但是，等等，当前正在`dev`上进行的工作还没有提交：

   ```
   $ git status
   On branch dev
   Changes to be committed:
     (use "git reset HEAD <file>..." to unstage)
   
   	new file:   hello.py
   
   Changes not staged for commit:
     (use "git add <file>..." to update what will be committed)
     (use "git checkout -- <file>..." to discard changes in working directory)
   
   	modified:   readme.txt
   ```

   并不是你不想提交，而是工作只进行到一半，还没法提交，预计完成还需1天时间。但是，必须在两个小时内修复该bug，怎么办？

   幸好，Git还提供了一个`stash`功能，可以把当前工作现场“储藏”起来，等以后恢复现场后继续工作：

   ```
   $ git stash
   Saved working directory and index state WIP on dev: f52c633 add merge
   ```

   现在，用`git status`查看工作区，就是干净的（除非有没有被Git管理的文件），因此可以放心地创建分支来修复bug。

   首先确定要在哪个分支上修复bug，假定需要在`master`分支上修复，就从`master`创建临时分支：

   ```
   $ git checkout master
   Switched to branch 'master'
   Your branch is ahead of 'origin/master' by 6 commits.
     (use "git push" to publish your local commits)
   
   $ git checkout -b issue-101
   Switched to a new branch 'issue-101'
   ```

   现在修复bug，需要把“Git is free software ...”改为“Git is a free software ...”，然后提交：

   ```
   $ git add readme.txt 
   $ git commit -m "fix bug 101"
   [issue-101 4c805e2] fix bug 101
    1 file changed, 1 insertion(+), 1 deletion(-)
   ```

   修复完成后，切换到`master`分支，并完成合并，最后删除`issue-101`分支：

   ```
   $ git switch master
   Switched to branch 'master'
   Your branch is ahead of 'origin/master' by 6 commits.
     (use "git push" to publish your local commits)
   
   $ git merge --no-ff -m "merged bug fix 101" issue-101
   Merge made by the 'recursive' strategy.
    readme.txt | 2 +-
    1 file changed, 1 insertion(+), 1 deletion(-)
   ```

   太棒了，原计划两个小时的bug修复只花了5分钟！现在，是时候接着回到`dev`分支干活了！

   ```
   $ git switch dev
   Switched to branch 'dev'
   
   $ git status
   On branch dev
   nothing to commit, working tree clean
   ```

   工作区是干净的，刚才的工作现场存到哪去了？用`git stash list`命令看看：

   ```
   $ git stash list
   stash@{0}: WIP on dev: f52c633 add merge
   ```

   工作现场还在，Git把stash内容存在某个地方了，但是需要恢复一下，有两个办法：

   一是用`git stash apply`恢复，但是恢复后，stash内容并不删除，你需要用`git stash drop`来删除；

   另一种方式是用`git stash pop`，恢复的同时把stash内容也删了：

   ```
   $ git stash pop
   On branch dev
   Changes to be committed:
     (use "git reset HEAD <file>..." to unstage)
   
   	new file:   hello.py
   
   Changes not staged for commit:
     (use "git add <file>..." to update what will be committed)
     (use "git checkout -- <file>..." to discard changes in working directory)
   
   	modified:   readme.txt
   
   Dropped refs/stash@{0} (5d677e2ee266f39ea296182fb2354265b91b3b2a)
   ```

   再用`git stash list`查看，就看不到任何stash内容了：

   ```
   $ git stash list
   ```

   你可以多次stash，恢复的时候，先用`git stash list`查看，然后恢复指定的stash，用命令：

   ```
   $ git stash apply stash@{0}
   ```

   在master分支上修复了bug后，我们要想一想，dev分支是早期从master分支分出来的，所以，这个bug其实在当前dev分支上也存在。

   那怎么在dev分支上修复同样的bug？重复操作一次，提交不就行了？

   有木有更简单的方法？

   有！

   同样的bug，要在dev上修复，我们只需要把`4c805e2 fix bug 101`这个提交所做的修改“复制”到dev分支。注意：我们只想复制`4c805e2 fix bug 101`这个提交所做的修改，并不是把整个master分支merge过来。

   为了方便操作，Git专门提供了一个`cherry-pick`命令，让我们能复制一个特定的提交到当前分支：

   ```
   $ git branch
   * dev
     master
   $ git cherry-pick 4c805e2
   [master 1d4b803] fix bug 101
    1 file changed, 1 insertion(+), 1 deletion(-)
   ```

   Git自动给dev分支做了一次提交，注意这次提交的commit是`1d4b803`，它并不同于master的`4c805e2`，因为这两个commit只是改动相同，但确实是两个不同的commit。用`git cherry-pick`，我们就不需要在dev分支上手动再把修bug的过程重复一遍。

   有些聪明的童鞋会想了，既然可以在master分支上修复bug后，在dev分支上可以“重放”这个修复过程，那么直接在dev分支上修复bug，然后在master分支上“重放”行不行？当然可以，不过你仍然需要`git stash`命令保存现场，才能从dev分支切换到master分支

### 4.Feature分支

1. 软件开发中，总有无穷无尽的新的功能要不断添加进来。

   添加一个新功能时，你肯定不希望因为一些实验性质的代码，把主分支搞乱了，所以，每添加一个新功能，最好新建一个feature分支，在上面开发，完成后，合并，最后，删除该feature分支。

   现在，你终于接到了一个新任务：开发代号为Vulcan的新功能，该功能计划用于下一代星际飞船。

   于是准备开发：

   ```
   $ git switch -c feature-vulcan
   Switched to a new branch 'feature-vulcan'
   ```

   5分钟后，开发完毕：

   ```
   $ git add vulcan.py
   
   $ git status
   On branch feature-vulcan
   Changes to be committed:
     (use "git reset HEAD <file>..." to unstage)
   
   	new file:   vulcan.py
   
   $ git commit -m "add feature vulcan"
   [feature-vulcan 287773e] add feature vulcan
    1 file changed, 2 insertions(+)
    create mode 100644 vulcan.py
   ```

   切回`dev`，准备合并：

   ```
   $ git switch dev
   ```

   一切顺利的话，feature分支和bug分支是类似的，合并，然后删除。

   但是！

   **就在此时，接到上级命令，因经费不足，新功能必须取消！**

   **虽然白干了，但是这个包含机密资料的分支还是必须就地销毁：**

   ```
   $ git branch -d feature-vulcan
   error: The branch 'feature-vulcan' is not fully merged.
   If you are sure you want to delete it, run 'git branch -D feature-vulcan'.
   ```

   销毁失败。Git友情提醒，`feature-vulcan`分支还没有被合并，如果删除，将丢失掉修改，如果要强行删除，**需要使用大写的`-D`参数**。

   现在我们强行删除：

   ```
   $ git branch -D feature-vulcan
   Deleted branch feature-vulcan (was 287773e).
   ```

   终于删除成功！

### 5. 多人协作

1. 当你从远程仓库克隆时，实际上Git自动把本地的`master`分支和远程的`master`分支对应起来了，并且，远程仓库的默认名称是`origin`。

   要**查看远程库的信息**，**用`git remote`：**

   ```
   $ git remote
   origin
   ```

   或者，**用`git remote -v`显**示更详细的信息：

   ```
   $ git remote -v
   origin  git@github.com:michaelliao/learngit.git (fetch)
   origin  git@github.com:michaelliao/learngit.git (push)
   ```

   上面显示了可以抓取和推送的`origin`的地址。如果没有推送权限，就看不到push的地址。

   **推送分支**

   **推送分支，就是把该分支上的所有本地提交推送到远程库**。推送时，要指定本地分支，这样，Git就会把该分支推送到远程库对应的远程分支上：

   ```
   $ git push origin master
   ```

   如果要推送其他分支，比如`dev`，就改成：

   ```
   $ git push origin dev
   ```

   但是，并不是一定要把本地分支往远程推送，那么，哪些分支需要推送，哪些不需要呢？

   - **`master`分支是主分支，因此要时刻与远程同步；**
   - **`dev`分支是开发分支，团队所有成员都需要在上面工作，所以也需要与远程同步；**
   - bug分支只用于在本地修复bug，就没必要推到远程了，除非老板要看看你每周到底修复了几个bug；
   - feature分支是否推到远程，取决于你是否和你的小伙伴合作在上面开发。

   总之，就是在Git中，分支完全可以在本地自己藏着玩，是否推送，视你的心情而定！

**抓取分支**

1. 多人协作时，大家都会往`master`和`dev`分支上推送各自的修改。

现在，模拟一个你的小伙伴，可以在另一台电脑（注意要把SSH Key添加到GitHub）或者同一台电脑的另一个目录下克隆：

```
$ git clone git@github.com:michaelliao/learngit.git
Cloning into 'learngit'...
remote: Counting objects: 40, done.
remote: Compressing objects: 100% (21/21), done.
remote: Total 40 (delta 14), reused 40 (delta 14), pack-reused 0
Receiving objects: 100% (40/40), done.
Resolving deltas: 100% (14/14), done.
```

当你的小伙伴从远程库clone时，**默认情况下，你的小伙伴只能看到本地的`master`分支。**不信可以用`git branch`命令看看：

```
$ git branch
* master
```

现在，你的小伙伴要在`dev`分支上开发，就必须创建远程`origin`的`dev`分支到本地，于是他用这个命令创建本地`dev`分支：

```
$ git checkout -b dev origin/dev
```

现在，他就可以在`dev`上继续修改，然后，时不时地把`dev`分支`push`到远程：

```
$ git add env.txt

$ git commit -m "add env"
[dev 7a5e5dd] add env
 1 file changed, 1 insertion(+)
 create mode 100644 env.txt

$ git push origin dev
Counting objects: 3, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (2/2), done.
Writing objects: 100% (3/3), 308 bytes | 308.00 KiB/s, done.
Total 3 (delta 0), reused 0 (delta 0)
To github.com:michaelliao/learngit.git
   f52c633..7a5e5dd  dev -> dev
```

你的小伙伴已经向`origin/dev`分支推送了他的提交，而碰巧你也对同样的文件作了修改，并试图推送：

```
$ cat env.txt
env

$ git add env.txt

$ git commit -m "add new env"
[dev 7bd91f1] add new env
 1 file changed, 1 insertion(+)
 create mode 100644 env.txt

$ git push origin dev
To github.com:michaelliao/learngit.git
 ! [rejected]        dev -> dev (non-fast-forward)
error: failed to push some refs to 'git@github.com:michaelliao/learngit.git'
hint: Updates were rejected because the tip of your current branch is behind
hint: its remote counterpart. Integrate the remote changes (e.g.
hint: 'git pull ...') before pushing again.
hint: See the 'Note about fast-forwards' in 'git push --help' for details.
```

推送失败，因为你的小伙伴的最新提交和你试图推送的提交有冲突，解决办法也很简单，Git已经提示我们，先**用`git pull`把最新的提交从`origin/dev`抓下来**，然后，在本地合并，解决冲突，再推送：

**意思就是：**两个人都拉取子相同的仓库，最开始的每个文件一摸一样，当其中一个人把修改推送后，远程仓库的文件内容变了，当第二个人在进行推送时，应与它拉取时的原始远程仓库比较进行远程仓库的更新，但是远程仓库变了，就没法推送了，所以要将目前最新远程仓库拉取下来，进行本地的合并，这样使得目前本地比远程仓库新，就可以推送了。

```
$ git pull
There is no tracking information for the current branch.
Please specify which branch you want to merge with.
See git-pull(1) for details.

    git pull <remote> <branch>

If you wish to set tracking information for this branch you can do so with:

    git branch --set-upstream-to=origin/<branch> dev
```

`git pull`也失败了，原因是没有**指定本地`dev`分支与远程`origin/dev`分支的链接**，根据提示，设置`dev`和`origin/dev`的链接：

```
$ git branch --set-upstream-to=origin/dev dev
Branch 'dev' set up to track remote branch 'dev' from 'origin'.
```

再pull：

```
$ git pull
Auto-merging env.txt
CONFLICT (add/add): Merge conflict in env.txt
Automatic merge failed; fix conflicts and then commit the result.
```

这回`git pull`成功，但是合并有冲突，需要手动解决，解决的方法和分支管理中的[解决冲突](http://www.liaoxuefeng.com/wiki/896043488029600/900004111093344)完全一样。解决后，提交，再push：

```
$ git commit -m "fix env conflict"
[dev 57c53ab] fix env conflict

$ git push origin dev
Counting objects: 6, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (4/4), done.
Writing objects: 100% (6/6), 621 bytes | 621.00 KiB/s, done.
Total 6 (delta 0), reused 0 (delta 0)
To github.com:michaelliao/learngit.git
   7a5e5dd..57c53ab  dev -> dev
```

因此，多人协作的工作模式通常是这样：

1. 首先，可以试图用`git push origin `推送自己的修改；
2. 如果推送失败，则**因为远程分支比你的本地更新**，需要先用`git pull`试图合并；
3. 如果合并有冲突，则解决冲突，并在本地提交；
4. 没有冲突或者解决掉冲突后，再用`git push origin `推送就能成功！

如果`git pull`提示`no tracking information`，则说明本地分支和远程分支的链接关系没有创建，用命令`git branch --set-upstream-to  origin/`。

这就是多人协作的工作模式，一旦熟悉了，就非常简单。

### 6.Rebase

在上一节我们看到了，多人在同一个分支上协作时，很容易出现冲突。即使没有冲突，后push的童鞋不得不先pull，在本地合并，然后才能push成功。

每次合并再push后，分支变成了这样：

```
$ git log --graph --pretty=oneline --abbrev-commit
* d1be385 (HEAD -> master, origin/master) init hello
*   e5e69f1 Merge branch 'dev'
|\  
| *   57c53ab (origin/dev, dev) fix env conflict
| |\  
| | * 7a5e5dd add env
| * | 7bd91f1 add new env
| |/  
* |   12a631b merged bug fix 101
|\ \  
| * | 4c805e2 fix bug 101
|/ /  
* |   e1e9c68 merge with no-ff
|\ \  
| |/  
| * f52c633 add merge
|/  
*   cf810e4 conflict fixed
```

总之看上去很乱，有强迫症的童鞋会问：为什么Git的提交历史不能是一条干净的直线？

其实是可以做到的！

Git有一种称为rebase的操作，有人把它翻译成“变基”。

先不要随意展开想象。我们还是从实际问题出发，看看怎么把分叉的提交变成直线。

在和远程分支同步后，我们对`hello.py`这个文件做了两次提交。用`git log`命令看看：

```
$ git log --graph --pretty=oneline --abbrev-commit
* 582d922 (HEAD -> master) add author
* 8875536 add comment
* d1be385 (origin/master) init hello
*   e5e69f1 Merge branch 'dev'
|\  
| *   57c53ab (origin/dev, dev) fix env conflict
| |\  
| | * 7a5e5dd add env
| * | 7bd91f1 add new env
...
```

注意到Git用`(HEAD -> master)`和`(origin/master)`标识出当前分支的HEAD和远程origin的位置分别是`582d922 add author`和`d1be385 init hello`，本地分支比远程分支快两个提交。

现在我们尝试推送本地分支：

```
$ git push origin master
To github.com:michaelliao/learngit.git
 ! [rejected]        master -> master (fetch first)
error: failed to push some refs to 'git@github.com:michaelliao/learngit.git'
hint: Updates were rejected because the remote contains work that you do
hint: not have locally. This is usually caused by another repository pushing
hint: to the same ref. You may want to first integrate the remote changes
hint: (e.g., 'git pull ...') before pushing again.
hint: See the 'Note about fast-forwards' in 'git push --help' for details.
```

很不幸，失败了，这说明有人先于我们推送了远程分支。按照经验，先pull一下：

```
$ git pull
remote: Counting objects: 3, done.
remote: Compressing objects: 100% (1/1), done.
remote: Total 3 (delta 1), reused 3 (delta 1), pack-reused 0
Unpacking objects: 100% (3/3), done.
From github.com:michaelliao/learngit
   d1be385..f005ed4  master     -> origin/master
 * [new tag]         v1.0       -> v1.0
Auto-merging hello.py
Merge made by the 'recursive' strategy.
 hello.py | 1 +
 1 file changed, 1 insertion(+)
```

再用`git status`看看状态：

```
$ git status
On branch master
Your branch is ahead of 'origin/master' by 3 commits.
  (use "git push" to publish your local commits)

nothing to commit, working tree clean
```

加上刚才合并的提交，现在我们本地分支比远程分支超前3个提交。

用`git log`看看：

```
$ git log --graph --pretty=oneline --abbrev-commit
*   e0ea545 (HEAD -> master) Merge branch 'master' of github.com:michaelliao/learngit
|\  
| * f005ed4 (origin/master) set exit=1
* | 582d922 add author
* | 8875536 add comment
|/  
* d1be385 init hello
...
```

对强迫症童鞋来说，现在事情有点不对头，提交历史分叉了。如果现在把本地分支push到远程，有没有问题？

有！

什么问题？

不好看！

有没有解决方法？

有！

这个时候，rebase就派上了用场。我们输入命令`git rebase`试试：

```
$ git rebase
First, rewinding head to replay your work on top of it...
Applying: add comment
Using index info to reconstruct a base tree...
M	hello.py
Falling back to patching base and 3-way merge...
Auto-merging hello.py
Applying: add author
Using index info to reconstruct a base tree...
M	hello.py
Falling back to patching base and 3-way merge...
Auto-merging hello.py
```

输出了一大堆操作，到底是啥效果？再用`git log`看看：

```
$ git log --graph --pretty=oneline --abbrev-commit
* 7e61ed4 (HEAD -> master) add author
* 3611cfe add comment
* f005ed4 (origin/master) set exit=1
* d1be385 init hello
...
```

原本分叉的提交现在变成一条直线了！这种神奇的操作是怎么实现的？其实原理非常简单。我们注意观察，发现Git把我们本地的提交“挪动”了位置，放到了`f005ed4 (origin/master) set exit=1`之后，这样，整个提交历史就成了一条直线。rebase操作前后，最终的提交内容是一致的，但是，我们本地的commit修改内容已经变化了，它们的修改不再基于`d1be385 init hello`，而是基于`f005ed4 (origin/master) set exit=1`，但最后的提交`7e61ed4`内容是一致的。

这就是rebase操作的特点：把分叉的提交历史“整理”成一条直线，看上去更直观。缺点是本地的分叉提交已经被修改过了。

最后，通过push操作把本地分支推送到远程：

```
Mac:~/learngit michael$ git push origin master
Counting objects: 6, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (5/5), done.
Writing objects: 100% (6/6), 576 bytes | 576.00 KiB/s, done.
Total 6 (delta 2), reused 0 (delta 0)
remote: Resolving deltas: 100% (2/2), completed with 1 local object.
To github.com:michaelliao/learngit.git
   f005ed4..7e61ed4  master -> master
```

再用`git log`看看效果：

```
$ git log --graph --pretty=oneline --abbrev-commit
* 7e61ed4 (HEAD -> master, origin/master) add author
* 3611cfe add comment
* f005ed4 set exit=1
* d1be385 init hello
...
```

远程分支的提交历史也是一条直线。